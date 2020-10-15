module UnitTests.OrderTests

open Xunit
open FsUnit
open OrderService

// Trying to find a way to fluently build an order

[<Fact>]
let ``Cancel order (pipe test)`` () =
    
    //Arrange
    let order = 
        OrderBuilder.withSingle()
        |> OrderBuilder.withStatusInProgress

    //Act
    order.Cancel()

    //Assert
    order.Status |> should equal OrderStatus.Canceled

[<Fact>]
let ``Cancel order (composition test)`` () =
    
    //Arrange
    let createOrder = 
        OrderBuilder.withSingle 
        >> OrderBuilder.withStatusInProgress

    let order = createOrder()

    //Act
    order.Cancel()

    //Assert
    order.Status |> should equal OrderStatus.Canceled




// Trying to find the best way build a list of orders

[<Fact>]
let ``Setup with multiple orders with composition, declare functions`` () =
            
    //Arrange
    let createInProgressOrder = OrderBuilder.withSingle >> OrderBuilder.withStatusInProgress
    let createCancelledOrder = OrderBuilder.withSingle >> OrderBuilder.withStatusCancelled
    
    let orders = [createInProgressOrder(); createCancelledOrder()] 

    //Act
    // This test is just to try it out with builders
        
    //Assert
    orders |> should haveLength 2
    orders.Item(0).Status |> should equal OrderStatus.InProgress
    orders.Item(1).Status |> should equal OrderStatus.Canceled


[<Fact>]
let ``Setup with multiple orders with composition, embedded functions`` () =
            
    //Arrange
    let orders = [
        (OrderBuilder.withSingle >> OrderBuilder.withStatusInProgress)()
        (OrderBuilder.withSingle >> OrderBuilder.withStatusCancelled)()
    ]
    
    //Act
    // This test is just to try it out with builders
    
    //Assert
    orders |> should haveLength 2
    orders.Item(0).Status |> should equal OrderStatus.InProgress
    orders.Item(1).Status |> should equal OrderStatus.Canceled
