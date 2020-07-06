module Tests

open Expecto
open FizzBuzz

[<Tests>]
let tests =
  testList "Example tests" [
    testCase "Three should be Fizz" <| fun _ ->
      Expect.equal (FizzBuzz.fizzbuzz 3) "Fizz" "Is not Fizz."
  ]
