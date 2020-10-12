module OrderListBuilder
open OrderService

let withSingle (orders : ResizeArray<Order>) = 
    orders.Add(Order())
    orders

let withStatusInProgress (orders : ResizeArray<Order>) = 
    let order = orders |> Seq.last
    order.StartProcessing()
    orders
