import { Product } from ".";

export type PagingProduct = {
    CurrentPage: number,
    Items: Array<Product>,
    PageSize: number,
    TotalItems: number,
    TotalPages: number
}