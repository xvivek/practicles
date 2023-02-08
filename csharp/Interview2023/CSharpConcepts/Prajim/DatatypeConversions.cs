namespace CSharpConcepts.Prajim
{
    public class DatatypeConversions
    {

        public bool ImplicitConversionToFloat(int value)
        {
            try
            {

                int i = value;

                float f = i;

                Console.WriteLine(f);

                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool ImplicitConversionToFloat(int value, Type type)
        {
            try
            {
                int i = value;

                switch (type.GetType().Name)
                {              
                    case "System.Float":
                        float f = i;
                        break;
                    case "System.Decimal":
                        decimal d = i;
                        break;
                    case "System.Double":
                        double db = i;
                        break;
                    default:
                        return false;
                }
                
                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool ExplicitConversionToInt(float value)
        {
            try
            {
                int i = (int)value;

                Console.WriteLine(i);

                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool Parse(object input, Type type)
        {
            try
            {
               
                switch (type.FullName)
                {
                    case "System.Int32":                        
                        int.Parse(input.ToString());
                        break;
                    case "System.Single":
                        float.Parse(input.ToString());
                        break;
                    case "System.Decimal":
                        Decimal.Parse(input.ToString());
                        break;
                    case "System.Double":
                        double.Parse(input.ToString());
                        break;
                    case "System.Boolean":
                        bool.Parse(input.ToString());
                        break;
                    default:
                        return false;
                }
               
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
