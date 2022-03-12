import { Product } from ".";

export  type Image = {
    ImageId: number,
    ImageName: string,
    Extension: string,
    ProductId: number,
    Url: string | undefined
    Product: Product | undefined
}