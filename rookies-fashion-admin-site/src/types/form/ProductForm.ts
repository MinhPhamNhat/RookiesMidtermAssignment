import { EditorState } from "draft-js";

export type ProductForm = {
    Name?: string;
    Description?: string;
    Price?: number;
    CategoryId?: number;
    Files: Array<File>;
    ColorIds?: Array<number>;
    SizeIds?: Array<number>;
}

