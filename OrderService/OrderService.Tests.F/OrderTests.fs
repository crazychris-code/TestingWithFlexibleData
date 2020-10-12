module UnitTests.OrderTests

open Xunit
open FsUnit
open OrderService

[<Fact>]
let ``Cancel order test`` () =
    
    //Arrange
    let order = 
        OrderBuilder.withSingle()
        |> OrderBuilder.withStatusInProgress

    //Act
    order.Cancel()

    //Assert
    order.Status |> should equal OrderStatus.Canceled






// Trying to find a way to fluently build a list of orders

[<Fact>]
let ``Setup with multiple orders immutable list`` () =
        
    //Arrange
    let orders = 
        (OrderBuilder.withSingle()
        |> OrderBuilder.withStatusInProgress
        |> OrderBuilder.build)
        @
        (OrderBuilder.withSingle()
        |> OrderBuilder.withStatusInProgress
        |> OrderBuilder.build)

    
    //Act
    
    //Assert
    Assert.True(true)

[<Fact>]
let ``Setup with multiple orders mutable list`` () =
        
    //Arrange
    let orders = 
        new ResizeArray<Order> ()
        |> OrderListBuilder.withSingle |> OrderListBuilder.withStatusInProgress
        |> OrderListBuilder.withSingle |> OrderListBuilder.withStatusInProgress

    
    //Act
    
    //Assert
    Assert.True(true)
