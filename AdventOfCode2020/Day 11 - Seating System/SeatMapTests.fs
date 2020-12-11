﻿module SeatMapTests

open FsUnit.Xunit
open Xunit
open SeatMap
open Xunit.Abstractions

type SeatMapTests(output: ITestOutputHelper) =

    [<Fact>]
    member __.``Example Data`` () =
        let input = "L.LL.LL.LL
LLLLLLL.LL
L.L.L..L..
LLLL.LL.LL
L.LL.LL.LL
L.LLLLL.LL
..L.L.....
LLLLLLLLLL
L.LLLLLL.L
L.LLLLL.LL"

        let r = simulate input
        r |> should equal 37

    [<Fact>]
    member __.``Puzzle Input`` () =
        let input = "LLLLLLLLL.LLLLL.LLLLLLLLL.LLLLLLLLLLLL.LLLLLL.LL.LLL.LL.L.LLLLLLLLLLLLLL.LLLLLLLLL.LLLLLLLLLLLL
LLLLLLL.LLLLLLL.LLLLLLLLLLLLLLLLLLLLLLLLLLLLL.LLLLLL.LLLLLLLLLLLLLLLLLLL.LLLLLLLLL.LLLLLLLLLLLL
LLLLLLLLLLLLLLL.LLLLLLLLL.LLLL.LLLLLLLLLLLLLL.LLLLLL.LLLL.LLLL.LLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLL
LLLLLLL.LLLLLLL.LLLLLLLLLLLLLL.LLLLLLL.LLLLLLLLLLLLL.LLLLLLLLLLLLLL.LLLL.LLLLLLLLL.LLLL.LLLLLLL
LLLLLLLLLLLLLLL.LLLLLLLLL.LLLL.LLLLLLLLLLLLLL.LLLLLL.LLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLL.LLLLLLLLL
LLLLLLL.LLLLLLL.LLLLLLLLL.LLLLLLLLLLLLLLLLLLLLLLLLLL.LLLLLLLLLLL.LL.LLLL.LLLLLLLLLLLLLLLLLLLLLL
LLLLLLL.LLLLLLL.LLLLLLLLLLLL.L.LLLLLLLLLLLLLL.LLLLLL.LLLL.LLLLLLLLL.LLLL.LLLL.LLLL.LLLLLLLLLLLL
L....LL.......L..LLLL...LLLLL.L.L.L...L...L.L..L.L.LL..L.L...L.LLLLLL..L..L.........L.L........
LLLLLLL.LLLLLLL.LLLLLLLLL.LLLL.L.LLLLL.LLLLLLLLLLLLL.LLLL.LLLLLLLLL.LLLL.LLLLLLLLL.LLLLLLLLLLLL
LL.LLLL.LLLLLLLLLLLLLLLLL.LLLLLLLLLLLL.LLLLLLLLLL.LL.LLLL.LLLLLLLLL.LLLLLLLLLLLLLL.LLLLLLLLLLLL
LLLLLLL.LLLLLLLLLLLLLLLLLLLLLL.LLLLLLL.LLLLLL.LLLLLL.LLLLLLLLLLLLLL.LLLL.LLLLLLLLLLLLLLLLLLLLLL
LLLLLLL.LLLLLLL.LLLLLLLLL.LLLLLLLLLLLL.LLLLLLLLLLLLL.LLLL.LLLLLLLLLLLLLLLLLLLLLLLL.LLLLLLLLLLLL
LLLLLLL.LLLLL.L.LLLLLLLLL.LLLL.LLLLLLL.LLLLLLLLLLLLLLLLLL.L.LLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLL
LLLLLLL.LLLLLLL.L.LLLLLLL.LLLL.LLLLLLLLLLLLLL.LLLLLL.LLLLLLLLLLLLLL.LLLLLLLLLLLLLL.LLLLLLLLLLLL
LLLLLLL.LLLLLLLLLLLLLLLLL.L.LL.LLLLLLLLLLLLLL.LLLLLL.LLLL.LL.LLLLLL.LLLL.LLLLLLLLLLLLLLL.LLLLLL
LLLLLLL.LLLLLLLLLLLLLLLLL.LLLLLLLLLLLLLLL..LLLLLLLLL.LLLL.LLLLLLLLLLLLLL.LLLLLLLLLLLLLLLLLLLLLL
.L..LLL....L....L...LLL.LL.....L....L...L....L.......L.L..L.L..L......LL......L.....L..L..L..L.
LLLLLLL.LLLLLLL.LLLLLLLLLLLLLL.LLLLLLL.LLLLLLL.LLLLLLLLLL.LLLLLLLLL.LLLL.LLLLLLLL..LLLLLLLLLLLL
LLLLLLL.LLLLLLL.LLLL.LLLL..LLLLLLLLLLL.LLLLLLLLLLLLL.LLLLLLLLLLLLLLLLLLL.LLL.LLLLL.LLLLLLLLLLLL
LLLL.LLLLLLLLL..LLLLL.LLL.LL.L.LLLLLLL.LLLLLL.LLLLLL.LLLLLLL.LLLLLL.LLLLLLLLLLLLLL.LLLLLLLLLLLL
LLLLLLL.LLLLLLL.LLL.LLLLL.LLLLLLLLLLLL.LLLLLLLLLLLLLLLLLL.LLLLLLLLLLLLLL.LLLLLLLLL.LLLLLLL.LLLL
LLLLLLL.L.LLLLLLLLLLLLLL..LLLLLLLLLLLL.LLLLLL.LLLLLLLLLLL.LLLLLLLLL.LLLL.LLLLLLLLLLL.LLLLLLLL.L
LLLLLLLLLLLLLLL.LLLLLLLLL.LLLL.LLLLLLL.LLLLLL.LLLLLL.LLLL.LLLLLLLLL.LLLLLLLLLLLLLL.LLLLLLLLL.LL
LLLLLLL.LLLLLLL.LLLLLLLLL.LLLL.LLL.L.L.LLLLLL.LLLLLL.LLLL.LLLLLLLLLLLLLL.LLL.LLLL...LLLLLLLLLLL
LLLLLLLLLLLLLLLLL.LLLLLLL.LLLL.LLLLLLL.LLLLLL.LLLLLL.LLLL.L.LLLLLLL.LLLL.LLLLLLLLL.LLLLLLLLLLLL
..L......L.....L...L..L......LLLLL....LLL..LL.L..L.....LLL.....L...LL.LL.LL.....L.....LL.LL.L.L
LLLLLLL.LLLL.LL.LLLLLLLLL.LLLL.LLLLLLL.LLLLLL.LLLLLL.LLLL.L.LLLLLLL.LLLL.LLLLLLLLL.LLLLLLLLLLLL
LLLLLLL.LLLLLLLLLLLLLLL.L.LLLLLLLLLLLL.LLLLLL.LLLLLL.LLLL.LLLLLLLLL.LLLL.LLLLLLLLL.LLLLLLLLLLLL
LLLLLLL.LLLLLLL.LLLLLL.LL.LL.LLLLLLLL..LLLLLL.LLLLL..LLLLL.LLLLLLLL.LLLL.LLLLLLLLLLLLLLLLLLLLLL
LLLLLLL.LLLLLLL.LLLLLLLLL.LLLLLLLLL.LLLL.LLLLLLLLLLL.LLLL.LLLLLLLLL.LLLL.LLLLLLLLL.LLLLLLLLLLLL
LLLLLLL.L.LLLLLLLLLLLLLLL.L.LL.LLLLLLLLLLLLLL.L.LLLL.LLLLLLLLLLLLLL.LL.L.L.LLLLLLL.LLLLLLLLLLLL
.LLLLLL.LLLLLLL.LLLLL.LLLLLLLL.LLLLLLLLLLLLLL.LLLLLL.LLLLLLLLLLLLLL.LLLL.LLLLLLLLL.LLLLLLLLLLLL
LLLLLLL.LLLLLLL.LLLLLLLLL.LLLL.LLLLLLLLLLLLLL.LLLLLL.LLLLLLLLLLLLLLLLLLL.LL.LLLLLLLLLLLLLLLLLLL
.LLLL..L.LL.............L.....LL...L...LLL..........L.LL..LL..LLL.............L.L.......L....LL
LLLLLLL.LLLLLLLLLLLLL.LLLLL.LL.LLLL.LL.LLLLLL.LLLL.LLLLLL.LLLLLLLLL.LL.L.LLLLLL.LLLLLLLLLL.LLLL
LLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLL.LLLLLL.LLLLLLLL.LLLLLLLLLLLL.LLLL.LLLLLLLLL.LLLLLLLLLLLL
LLLLLLL.LLL..LL.LLLLLLLLL.LLLLLLLL.LLL.LLLLLL.LLLL.L.LLLL.LLLLLLLLL.LLLL.LLLLLL.LL.LLLLLLLLLLLL
L.LLLLL.LLLLLLLLLLLLLLLLL.LLLL.LLL.LLL.LLLLLL.LLLL.L.LLLLLLLLLLLLLL.LLLLLLL.LLLLLL.LLLLLLLLLLLL
LLLLLLL.LLLLLLLL.LLLLLLLLLLLLLLLLLLLLL.LLLLLL.LLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLL
LLL....L..L.L...L...LL......L..L..L...LL.L.LLL..L...L.....L......L...LL.L.L...L......LL.....LL.
LLLLLLL.LLLLLLL.LLLLLLLLL.LLL.LLLLLLLL.L.LLLL.L.LLLL.L.LL.LLLLLLLLL.LLLL.LLLLLLLLLLLLLLLLLLLLLL
LLLLLLL.LLLLLLL.LLLLLLLLLLLLLLLLLLL.LL..LLLLLLLLLLLLLLLLL.LLLLLLLLL.LLLLLLLLLLLLLLLLLLLLLL.LLLL
LLL.LLLLLLLLLLLLLLLLLLL.L.LLLL.LLL.LLL.LLLLLL.LLLLLL..LLL.LLLLLLLLLLLLLL.LLLLLL.LL.LLLLLLLLLLLL
LLLLL.L.LLLLLLLLLLLLLLLLL.LLLL.LLLLLLL.LLLLLL.LLLLLL.LLLL.LLLLLLLL..LLLL.L.LLL.LLLLLLLLLLLLLLLL
L.LLLLL.LLLLLLL.LLLLLLL.LLLLLLLLLLLLLL.LLLLLL.LLLLLL.LLLL.LLLLLLLLLLLLLL.LLLLLLLLL.LLLLLLLLLLLL
.LLLL.L.LLLLLLL.LLLLLL.LL.LLLLLLLLLLLL.LLLLLL.LLLL.L.LLLLLLLLLLLLLL.LLLLLLLLLLLLL..LLLLLLLLLLLL
.L.LL..L.L.L...LL.L..L..LL.L.LL.L.LLL........L....L.L.....L.....LL.L.L...LL..L.L..L.L..LLLL.LL.
LLLLLLL.LLLLLLL.LLLLLLLLL.LLLLLLLLLLLL.LLLLLL.LLLLLL.LLLL.LLLLLLLL..LLLL.LLLLLLLLL.LLLLLLLLLLLL
LLLLLLLLLLLLLLLLLLLLLLLLLLLLLL.LLLLLLLLLLLLLL.LLLLLL.LLLLLLLLLLLLLL.LLLL..LLLLLLLL.L.LLLLLLLLLL
LLLLLLL.LLLLLLLLLLLLLLLLL.LLLL.LLLLLLL.LLLLLL.LLLLLL.LLLL.LLLLLLLLLLLLLL.LLLLLLLLLLLLLLLLLLLLLL
LLLLLLL.LLLLLLL.LLLLLLLLL.LLLL.LLLLLLL.LLLLLL.LLLLLL.LLLL.LLLLLLLLL.LLLLLLLLLLLLLL.LLLLLL.LLLLL
...LL...LL..L...L..L.....LLL.LL.L....L..L..LLL...L.....L.L..L.LLL.L.L....LLL..L....L..L..LL.L.L
LLLLLLL.LLLLLLL.LLLLLLLLL.LLLL.LL.LLL..LLLLLLLLLLLLLLLLLL.LLLLLLLLLLLLLL.LLLLLLLLL.LLLLLLLLLLLL
LLLLLLL..LLLLLLLLLLLLLLLLLLLLL.LLLLLLL.LLLLLL.LLLLLL.L.LL.LLLLLLLLL.LLLL.LLLLLLLLL.LLLL.LLLLLLL
LLLLLLLLLLLLLLLLLLLLLLLLL.LLLL.LLLLLLL.LLLLLLLLLLLLL.LLL.LLLLLLLLLL..LLL.LLLLLLLLLLL.LLLL.LLLLL
LLLLLLL.LLLL.LLL.LLLLLLL.LLLLL.LLLLLLL..LLLLL.LLLLLLLLLLL.LLLLLLLLL.LL.L.LLLLLLLLL.LLLLLLLLLLLL
....L.L.L..L.....L...LLL...L.........L...L..........LLL.....L..........L...LL......LL..L.......
LLLLLLL.LLLLLLLLLLLLLLLLL.LLLL..LLL.LL.LLLLLL.LLLLLL.LLLLLLLLLLLLLL.LLLLLLL.LLLLLLL.L.LLLLLLLLL
LLLLLLL.LLLLLLL.LLLLLLLLL.LLLL.LLLLLLLLLLLLLL.LLLLLL.LLLLLLLLLLLLLL.LLLL.LLLL.LLLL.LLLLLLLLLLLL
LLLLLLLLLLLLLLL.LLLLLLLLLLLLLL.LLLLL.L.LLLLLLLLLLLLL.LLLL.LLLLLLLLL.L.LL.LLLLLLLLL.LLLLLLLLLLLL
LLLLLLLLLLLLLLLLLLLLLLLLL.LLLLLLLLLLLLLLLLLLLLLLLLLL.LLLL.LLLLLLLLL.LLLL.LLLLLLLLL.LLLLLLLLLLLL
LLL.LL..LLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLL.LLLLLL.LLLLLLLLLLLLLL.LLLL.LLLLLLLLLLLLLLLLLLLLLL
LLLLLLL.LL.LLLL.LLLLLLLLL..LLL.LLLLLLL.LLLLLLLLLLLLL.LLLLLLLLLLLLLLLLLLL.LLLLLLLLL.LLLLLLLLLLLL
.....LL..L.L..L..LL...L..........L.LL.LLLLL.L...L.L.....L..LL...L..LL......LL...L..L.L.L..LLL..
LLLLLLL.LLLLLLL.LLLLLLLLLLLLLLLLLLLLLL.LLLLLL.LLLL.LLLLLL.LLLL.LLLLLLLLL.LLLL.LLLLLLLLLLLLLLLLL
LLLLLLL.LLLLLLL.LLLLLLLLL.LLLL.LLLLLLL.LLLLLL.LLLLLL.LLLL.LLLLLLLLL.LLLL.LLLL.LLLL.LLLLLLLLL.LL
LLLLL.L.LLLLLLL.LLLLLLLLL.LLLL.LL.LLLL.L.LLLL.LLLLLL.LLLL.LLL.LLLLL.LLLL.LLLLLLLLLLLLLLLLLLLL.L
LLLLLLL.LLLLLLLLLLLLLLLLL.LLLL.L.LLLLL.LLLLLL.LLLLLL.LLLL.LLLLLLLLL.L.LLLLLLLLLLLL.LLLLLLLLLLLL
L.LLLLL.LLLLLLL.LLLLLLLLL.LLLL.LLLLLLL.LLLLLL.LLLLLL.LLLL.LLL.LL.LL.L.LL.LLLLLLLLL.LLLLLLLLLLLL
LLLLLLL.LLLLLLLLL.L.LLLLL.LLLL.LLLLLLLLLLLLLL.LLLLLL.LLLLLLLLLLLLLLLLL.L.LLLLLLLLL.LLLLLLLLLLLL
LL....L.L..L.L..L...LL..........LL......L..LL....L.LL...L..L.L.L..L..LL....LL..L..L.......L.L..
LLLLLLL.LLLLLLLLLLLLLLLLL..LLL.LLLLLLL.LLLL.L.LLLLLLLLLL..LLLLLLLLL.LL.L.LLLLLLLLL.LLLLLLLLLLLL
LLLLLLLLLLLLLLL.LLLLLLLLLLLLLL.LLLLLLLLLLL.LL.LLLLLL.LLLL.LLLLLLLLLLLLLL.LLLLLLLLL.LLLLLLLLLLLL
LLLLLLL.LLLLLLLLLLLLLLLLL.LLLL.LLLLLLL.LLLLLL.LLLLLL.LLLLLLLLLLLLLL.LLLL.LLL.LLLLL.LLLLLLLLLLLL
LLLLLLL.LLLLLLLLLLLLLLLLL.LLLLLLLLLLLL.LLLLLLLLLLLLL.LLLL.LLLLLLLL..LLLL.LLLLLLLL..LLLLLLLLL.LL
LLLLLLL.LLLLLLLLLLLLL.LLL.LLLL.LLLLLLL.LLL.LL.LLLLLL.LLLLLLLLLLLLLL.LLLL.LLLLLLLLL.LLLLLLLLLLLL
LLLLLLL.LLLLLLLLLLLLLLLLL.LLLL.LLLLLLLLLLLLLLLLL.LLLLLLLL..LLLLLLLLLLLLL.LLLLLLLLL.LLLLLLLLLLLL
.LL...LL.L....L.L.......LL.......LL...LL....LL.L.LL..L..L...LL........LL..L...L.LL...L..L.L...L
LLLLLLL.LLLLLLL.LLLLLLLLLLLLLL.L.LLLLL.LLLLLL.LLLLLL.LLLLLLLLLLLLLL.LLLL.LLLLLLLLL.LLLLLLLLLLLL
LLLLLLLLLLLLLLL.LLLLLLLLL.L.LL.LLLLLLLLLLLLLL.LLLLLL..LLL.LLLLLLLLL.LLLLLLL.LLLLLLLLLLLLLLLLLLL
LLLLLLL..LLLLLLLLLLLLLLLLLLLLLLLLLL.LL..LLLLL.LL.LLL.LLLLLLLLL.LLLL.LLLLLLLLLLLLLL.LLLLLLLLLLLL
LLLLLLL.LLLLLLL.LLLLLLLLL.LLLL.LLLLLLL.LLLLLL.LLLLLLLLLLLLLLLLLLLLL.LLLLLLLLLLLL..LLLLLLLLLLLLL
LLLLLLLLLLLLLLL.LLLLLLLLL.LLLLLLLLLLLLLLLLL.L.LLLLLLLLLLL.LLLLLLLLLLLLLL.LLLLLLLLL.LLL.LLLLLLLL
L.LLLLLLLLLLLLL.LLLLLLLLL.LLLL.LLLLLLL.LLLLLL.LLLLLL.LL.LLLLLLLLLLL.LLLL.LLLLLLLLL.LLLLLLLLLLLL
..LL..L.....L..L.....LL.....L.........L.......L..LL.L.LL......LL.L.L.....L...LL.......L......LL
LLLLLLLLLLLLLLLLLL.LLLLLL.LLL..L.LLLLL.LLLLLL.LLLLLL.LLLL.LLLL.LLLL.LLLLLLLLLLLLLL.LLLLLLLLLLLL
LLLLLLL.LLLLLLL.LLLLL.LLL.LLLL.LLLLLLL.LLLLLL.L.LLLLLLLLLLLLLLLLLLL.LLLL.LLLLLLLLLLLLLLLLLLLLLL
LLLLLLL.LLLLLLL.LLLLLLLLL.LLLLLLLLLLLL.LLLLLL.LLLLLLLLLLLLLLLLLLLLL.LLLL.LLLLLLLL..LLLLLLLLLLLL
LLLLLLLLLLLLLLL.LLLLLLLLLLLLLL.LLLLLLL.LL.LLL..LLLLLLLLLL.LLLLLLLLL.LLLLLLL.LLLLLLLLLLLLLLLLLLL
LLLLLLL..LLLLLLLLLLLL.LLLLLLLL.LLLLLLLLLLLLLL.LLLLLL.LLLLLLLLLLLLLLLLLLL.LLLLLLLLL.LLLLLLLLLLLL
LLLLLLL.LLLLLLL.LLL.LLLLL.LLLL.LLLLLLL.LLLLLLLLLLLLL.LLLL.LLLLLLLLL.LLLLLLLLLLLLLL.LLL.LLLLLLLL"

        let r = simulate input
        output.WriteLine("Occupied {0}", r)