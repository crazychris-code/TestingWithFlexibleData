module OrderBuilder
open OrderService

let withSingle () = 
    Order()

let withStatusInProgress (order : Order) = 
    order.StartProcessing()
    order

let build (order : Order ) = 
    [order]