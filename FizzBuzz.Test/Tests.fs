module Tests

open Expecto
open FsCheck
open FizzBuzz

let multipleOfThree n = n * 3
let multipleOfFive n = n * 5
let multipleOfBoth n = n * 15
let noMultiple n = (multipleOfBoth n) - 1

type ThreeGenerator =
    static member ThreeMultiple() =
        Arb.generate<NonNegativeInt>
        |> Gen.map (fun (NonNegativeInt n) -> multipleOfThree n)
        |> Gen.filter (fun n -> n > 0)
        |> Arb.fromGen

let multipleOfThreeConfig =
    { FsCheckConfig.defaultConfig with
          arbitrary = [ typeof<ThreeGenerator> ] }

type FiveGenerator =
    static member FiveMultiple() =
        Arb.generate<NonNegativeInt>
        |> Gen.map (fun (NonNegativeInt n) -> multipleOfFive n)
        |> Gen.filter (fun n -> n > 0)
        |> Arb.fromGen

let multipleOfFiveConfig =
    { FsCheckConfig.defaultConfig with
          arbitrary = [ typeof<FiveGenerator> ] }

type BothGenerator =
    static member BothMultiple() =
        Arb.generate<NonNegativeInt>
        |> Gen.map (fun (NonNegativeInt n) -> multipleOfBoth n)
        |> Arb.fromGen

let multipleOfBothConfig =
    { FsCheckConfig.defaultConfig with
          arbitrary = [ typeof<BothGenerator> ] }

type NoMultipleGenerator =
    static member BothMultiple() =
        Arb.generate<NonNegativeInt>
        |> Gen.map (fun (NonNegativeInt n) -> noMultiple n)
        |> Arb.fromGen

let noMultipleConfig =
    { FsCheckConfig.defaultConfig with
          arbitrary = [ typeof<NoMultipleGenerator> ] }

[<Tests>]
let tests =
    testList "Property based tests"
        [ testPropertyWithConfig multipleOfThreeConfig "Multiple of three should contain Fizz"
          <| fun x -> Expect.containsAll (FizzBuzz.fizzbuzz x) "Fizz" "Not contain Fizz"

          testPropertyWithConfig multipleOfFiveConfig "Multiple of five should contain Buzz"
          <| fun x -> Expect.containsAll (FizzBuzz.fizzbuzz x) "Buzz" "Not contain Buzz"

          testPropertyWithConfig multipleOfBothConfig "Multiple of both should be FizzBuzz"
          <| fun x -> Expect.equal (FizzBuzz.fizzbuzz x) "FizzBuzz" "Is not FizzBuzz"

          testPropertyWithConfig noMultipleConfig "Other number should be the same"
          <| fun x -> Expect.equal (FizzBuzz.fizzbuzz x) (string x) "Is not the same" ]
