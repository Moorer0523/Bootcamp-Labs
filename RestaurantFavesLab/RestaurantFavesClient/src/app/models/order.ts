export type Orders = Order[]

export interface Order {
  id: number
  description: string
  restaurant: string
  rating: number
  orderAgain: boolean
}

// export class Order {
//   public constructor(init?: Partial<Order>){
//     Object.assign(this, init)
//   }
// }

