export type ProductForm = {
    Name?: string;
    Description?: string;
    Price?: number;
    CategoryId?: number;
    Files: Array<File>;
    ColorIds?: Array<number>;
    SizeIds?: Array<number>;
}

// {"Search":"Rainbow ","Rating":null,"CategoryId":null,"SortOrder":0,"Page":1,"Limit":2}