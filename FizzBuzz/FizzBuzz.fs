namespace FizzBuzz

module FizzBuzz  =
    let fizzbuzz (x:int) = 
        match x with 
        | 3 -> "Fizz"
        | 5 -> "Buzz"
        | 9 -> "Fizz"
        | 15 -> "FizzBuzz"
        | 25 -> "Buzz"
        | _ -> string x
