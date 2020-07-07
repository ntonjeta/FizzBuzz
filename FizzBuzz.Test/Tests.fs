module Tests

open Expecto
open FizzBuzz


let rnd = System.Random()
let genRandomNumbers count = List.init count (fun _ -> rnd.Next())
let randomList = genRandomNumbers 100

let actualList =
    randomList |> List.map (FizzBuzz.fizzbuzz)

let expectedList =
    randomList
    |> List.map (fun i ->
        match i with
        | n when i % 3 = 0 && i % 5 = 0 -> "FizzBuzz"
        | n when i % 3 = 0 -> "Fizz"
        | n when i % 5 = 0 -> "Buzz"
        | _ -> string i)

[<Tests>]
let tests =
    testList "Example tests"
        [ testCase "Three should be Fizz"
          <| fun _ -> Expect.equal (FizzBuzz.fizzbuzz 3) "Fizz" "Is not Fizz."

          testCase "Five should be Buzz"
          <| fun _ -> Expect.equal (FizzBuzz.fizzbuzz 5) "Buzz" "Is not Buzz."

          testCase "Nine should be Fizz"
          <| fun _ -> Expect.equal (FizzBuzz.fizzbuzz 9) "Fizz" "Is not Fizz."

          testCase "Twentyi-Five should be Buzz"
          <| fun _ -> Expect.equal (FizzBuzz.fizzbuzz 25) "Buzz" "Is not Buzz."

          testCase "Fifteen should be FizzBuzz"
          <| fun _ -> Expect.equal (FizzBuzz.fizzbuzz 15) "FizzBuzz" "Is not FizzBuzz."

          testCase "Random number test"
          <| fun _ -> Expect.sequenceEqual actualList expectedList "Not equal" ]
