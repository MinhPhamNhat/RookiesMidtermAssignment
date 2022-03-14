import { Product } from ".";

export  type Image = {
    ImageId: number,
    ImageName: string,
    Extension: string,
    ProductId: number,
    ImageUrl: string | undefined
    Product: Product | undefined
}