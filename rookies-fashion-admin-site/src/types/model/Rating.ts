import { Product, User } from ".";

export type Rating = {
  RatingId: number;
  RatingVal: number;
  Comment: string;
  CreatedDate: Date;
  ProductId: number;
  Product: Product;
  UserRatingUserId: number;
  UserRating: User;
}
