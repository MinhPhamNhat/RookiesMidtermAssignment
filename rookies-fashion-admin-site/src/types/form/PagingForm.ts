import { SortOrder } from "../../constants";

export type PagingForm = {
    Search?: string;
    CategoryId?: number;
    Page?: number;
    Rating?: number;
    SortOrder?: SortOrder,
    Limit?: number;
}

