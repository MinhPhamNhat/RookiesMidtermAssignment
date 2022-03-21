export type ProductForm = {
    ProductId?: number;
    Name?: string;
    Description?: string;
    Price?: number;
    CategoryId?: number;
    Files: Array<File>;
    ColorIds?: Array<number>;
    SizeIds?: Array<number>;
}
