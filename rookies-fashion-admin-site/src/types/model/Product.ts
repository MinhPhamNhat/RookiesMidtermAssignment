import {
  Category,
  Rating,
  Image,
  Color,
  Size,
  UpdatedDate,
} from ".";

export type Product = {
  ProductId: number;
  Name: string;
  Description: string;
  Price: number;
  CategoryId: number;
  CreatedDate: string;
  Category: Category;
  Ratings: Array<Rating>;
  AvgRating: number;
  Thumbnail: Array<Image>;
  UpdatedDates: Array<UpdatedDate> | undefined;
  Colors: Array<Color>;
  Sizes: Array<Size>;
}
