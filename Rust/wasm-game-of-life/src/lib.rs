mod utils;

use wasm_bindgen::prelude::*;

#[wasm_bindgen]
extern "C" {
    fn alert(s: &str);
}

#[wasm_bindgen]
pub fn greet() {
    alert("Hello, wasm-game-of-life!");
}

//https://hackernoon.com/building-a-simple-web-app-with-rust-and-webassembly-a-step-by-step-guide?source=rss
//https://rustwasm.github.io/book/game-of-life/hello-world.html
#[wasm_bindgen]
pub extern "C" fn factorial(n: u32) -> u32 {
    if n == 0 {
        1
    } else {
        n * factorial(n - 1)
    }
}