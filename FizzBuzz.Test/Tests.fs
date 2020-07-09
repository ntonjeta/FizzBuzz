module Tests

open Expecto
open FsCheck
open FizzBuzz

let multipleOfThree n = n * 3

type ThreeGenerator =
    static member ThreeMultiple() =
        Arb.generate<NonNegativeInt>
        |> Gen.map (fun (NonNegativeInt n) -> multipleOfThree n)
        |> Arb.fromGen

let multipleOfThreeConfig =
    { FsCheckConfig.defaultConfig with
          arbitrary = [ typeof<ThreeGenerator> ] }

[<Tests>]
let tests =
    testList "Property based tests"
        [ testPropertyWithConfig multipleOfThreeConfig "Multiple of three should contain Fizz"
          <| fun x -> Expect.containsAll (FizzBuzz.fizzbuzz x) "Fizz" "Not contain Fizz" ]

// testList "Example tests"
//     [ testCase "Three should be Fizz"
//       <| fun _ -> Expect.equal (FizzBuzz.fizzbuzz 3) "Fizz" "Is not Fizz."

//       testCase "Five should be Buzz"
//       <| fun _ -> Expect.equal (FizzBuzz.fizzbuzz 5) "Buzz" "Is not Buzz."

//       testCase "Nine should be Fizz"
//       <| fun _ -> Expect.equal (FizzBuzz.fizzbuzz 9) "Fizz" "Is not Fizz."

//       testCase "Twentyi-Five should be Buzz"
//       <| fun _ -> Expect.equal (FizzBuzz.fizzbuzz 25) "Buzz" "Is not Buzz."

//       testCase "Fifteen should be FizzBuzz"
//       <| fun _ -> Expect.equal (FizzBuzz.fizzbuzz 15) "FizzBuzz" "Is not FizzBuzz." ]
