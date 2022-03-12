import {
  Category,
  Rating,
  Image,
  Color,
  Size,
  UpdatedDates,
} from ".";

export type Product = {
  ProductId: number;
  Name: string;
  Description: string;
  Price: number;
  CategoryId: number;
  CreatedDate: Date;
  Category: Category;
  Ratings: Array<Rating>;
  AvgRating: number;
  Thumbnail: Array<Image>;
  UpdatedDates: UpdatedDates | undefined;
  Colors: Array<Color>;
  Sizes: Array<Size>;
}
