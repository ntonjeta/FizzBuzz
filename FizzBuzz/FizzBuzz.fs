namespace FizzBuzz

module FizzBuzz  =
    let fizzbuzz (x:int) = 
        match x with 
        | n when n%3=0 && n%5=0 -> "FizzBuzz"
        | n when n%3=0 -> "Fizz"
        | n when n%5=0 -> "Buzz"
        | _ -> string x
