enum SortOrder {
  ALL = 0,
  NAME_ASC = 1,
  NAME_DESC = 2,
  PRICE_ASC = 3,
  PRICE_DESC = 4,
  RATING_ASC = 5,
  RATING_DESC = 6,
  CREATED_DATE_ASC = 7,
  CREATED_DATE_DESC = 8,
}

enum SortType {
  NAME = "NAME",
  PRICE = "PRICE",
  RATING = "RATING",
  CREATED_DATE = "CREATED_DATE",
}

const SortOrderValue: any = SortOrder;

export { SortOrder, SortType, SortOrderValue };
