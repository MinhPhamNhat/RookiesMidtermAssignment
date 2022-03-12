import { Product } from ".";

export type Category = {
  CategoryId: number;
  Name: string;
  Description: string;
  IsParent: boolean | false;
  ParentCategoryId: number | undefined;
  Parent: Category;
  Children: Array<Category> | undefined;
  Products: Array<Product> | undefined;
}
