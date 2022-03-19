import { Category } from ".";

export type PagingCategory = {
    CurrentPage: number,
    Items: Array<Category>,
    PageSize: number,
    TotalItems: number,
    TotalPages: number
}