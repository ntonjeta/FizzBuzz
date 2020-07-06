module Tests

open Expecto
open FizzBuzz

[<Tests>]
let tests =
  testList "Example tests" [
    testCase "Three should be Fizz" <| fun _ ->
      Expect.equal (FizzBuzz.fizzbuzz 3) "Fizz" "Is not Fizz."

    testCase "Five should be Buzz" <| fun _ ->
      Expect.equal (FizzBuzz.fizzbuzz 5) "Buzz" "Is not Buzz."

    testCase "Nine should be Fizz" <| fun _ ->
      Expect.equal (FizzBuzz.fizzbuzz 9) "Fizz" "Is not Fizz."
  ]
