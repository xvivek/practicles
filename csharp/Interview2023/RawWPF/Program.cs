// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using System;
using System.Windows;
using System.Speech.Recognition;
using System.Text;
using System.Windows.Controls;
using System.Speech.AudioFormat;
using System.IO;
using System.Globalization;
using System.Xml.XPath;
using System.Data;
using System.ServiceModel.Syndication;
using System.Xml;

namespace Petzold.SayHello
{
    class SayHello
    {
        [STAThread]
        public static void Main()
        {

            Window win = new Window();
            win.Title = "Say Hello";
            Grid grid = new Grid();
            RichTextBox textBox = new RichTextBox();
            textBox.AppendText("HI");
            grid.Children.Add(textBox);
            win.Content = grid;
            win.Show();

            GetLatestFivePosts();

            Application app = new Application();
            app.Run();
        }

        static bool completed;
        static StringBuilder sb = new StringBuilder();
        private static string MP3ToText()
        {

            using (SpeechRecognitionEngine sre = new SpeechRecognitionEngine(new CultureInfo("en-US")))
            {
                Grammar gr = new DictationGrammar();
                sre.LoadGrammar(gr);
                SpeechAudioFormatInfo speechAudioFormatInfo = new SpeechAudioFormatInfo(44100, AudioBitsPerSample.Sixteen, AudioChannel.Stereo);
                sre.SetInputToAudioStream(File.OpenRead("D:\\Download\\SML0320231108149571.mp3"), speechAudioFormatInfo);
                sre.BabbleTimeout = new TimeSpan(Int32.MaxValue);
                sre.InitialSilenceTimeout = new TimeSpan(Int32.MaxValue);
                sre.EndSilenceTimeout = new TimeSpan(100000000);
                sre.EndSilenceTimeoutAmbiguous = new TimeSpan(100000000);

                // sre.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(SpeechRecognizedHandler);
                // sre.RecognizeCompleted += new EventHandler<RecognizeCompletedEventArgs>(RecognizeCompletedHandler);

                completed = false;

                //sre.RecognizeAsync(RecognizeMode.Multiple);

                while (true)
                {
                    try
                    {
                        var recText = sre.Recognize();
                        if (recText == null)
                        {
                            break;
                        }

                        sb.Append(recText.Text);
                    }
                    catch (Exception ex)
                    {
                        //handle exception      
                        //...

                        break;
                    }
                }

                while (!completed)
                {
                    Thread.Sleep(333);
                }

                Console.WriteLine("Done.");
            }

            return sb.ToString();
        }

        static void SpeechRecognizedHandler(object sender, SpeechRecognizedEventArgs e)
        {
            if (e.Result != null && e.Result.Text != null)
            {
                Console.WriteLine("  Recognized text =  {0}", e.Result.Text);
            }
            else
            {
                Console.WriteLine("  Recognized text not available.");
            }
        }

        // Handle the RecognizeCompleted event.  
        static void RecognizeCompletedHandler(object sender, RecognizeCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                Console.WriteLine("  Error encountered, {0}: {1}",
                  e.Error.GetType().Name, e.Error.Message);
            }
            if (e.Cancelled)
            {
                Console.WriteLine("  Operation cancelled.");
            }
            if (e.InputStreamEnded)
            {
                Console.WriteLine("  End of stream encountered.");
            }

            completed = true;
        }

        public static void GetFeed2()
        {
            string url = "https://app.needl.ai/feeds/home/rss_news";
            XmlReader reader = XmlReader.Create(url);
            SyndicationFeed feed = SyndicationFeed.Load(reader);
            reader.Close();
            foreach (SyndicationItem item in feed.Items)
            {
                String subject = item.Title.Text;
                String summary = item.Summary.Text;
            }
        }
        public static void GetFeed()
        {
            try
            {
                string rssURL = "https://forum.valuepickr.com/u/hitesh2710/activity";
                // Bring back the Feed
                XPathDocument doc = new XPathDocument(rssURL);
                XPathNavigator nav = doc.CreateNavigator();
                XPathNodeIterator iter = nav.Select("");
                // Loop through the nodes
                while (iter.MoveNext())
                {
                    // Get the data we need from the node
                    ProcessNode(iter.Current);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }
        static void ProcessNode(XPathNavigator lstNav)
        {
            string title = "";
            string link = "";
            string description = "";
            // Get the child nodes
            XPathNodeIterator iterNews = lstNav.SelectDescendants(XPathNodeType.Element, false);
            // Loop through the child nodes
            while (iterNews.MoveNext())
            {
                var item = iterNews.Current;

                //// Save the current Name
                //string rssName = iterNews.Current.Name;
                //// Is this the title?
                //if (rssName.ToUpper() == rssTitle.ToUpper())
                //{ title = iterNews.Current.Value; }
                //// Is this the Link?
                //if (rssName.ToUpper() == rssLink.ToUpper())
                //{ link = iterNews.Current.Value; }
                //// Is this the Description?
                //if (rssName.ToUpper() == rssDescription.ToUpper())
                //{ description = iterNews.Current.Value; }
            }
        }


        public static IEnumerable<FeedItem> GetLatestFivePosts()
        {
            var s = new XmlReaderSettings();
            s.ProhibitDtd = false;

           //var reader = XmlReader.Create("https://sibeeshpassion.com/feed/");
           var reader = XmlReader.Create("https://app.needl.ai/feeds/home/rss_news/",s);
        
            var feed = SyndicationFeed.Load(reader);
            reader.Close();
            return (from itm in feed.Items
                    select new FeedItem
                    {
                        Title = itm.Title.Text,
                        Link = itm.Id
                    }).ToList().Take(5);
        }

        public class FeedItem
        {
            public string Title
            {
                get;
                set;
            }
            public string Link
            {
                get;
                set;
            }
        }
    }
}

