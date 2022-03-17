import { useEffect, useState } from "react";
import AsyncSelect from "react-select/async";
import Select from "react-select";
import { categoryService } from "../../services";
import Option from "../../components/Option";
import "./index.css";
import { Category } from "../../types/model";
import { Button } from "react-bootstrap";
const TableFilter = ({
  getPagingProducts,
  pagingProduct,
  actionType,
  pagingForm,
  setPagingForm,
  onChanging,
  setOnChanging,
  loading,
  setLoading,
}: any) => {
  const [categoryOptions, setCategoryOptions] = useState<any>([]);
  const [defaultCategoryOption, setDefaultCategoryOption] = useState<any>({
    value: 0,
    name: "All",
    label: <Option.Category name={"All"} isParent={true} value={0} />,
  });
  const [search, setSearch] = useState("");
  const promiseCategoryOptions = async () => {
    var data = (await categoryService.getCategories()).data;
    var out = [defaultCategoryOption].concat(
      data.map((c: Category) => {
        return {
          value: c.CategoryId,
          name: c.Name,
          label: (
            <Option.Category
              name={c.Name}
              isParent={c.IsParent}
              value={c.CategoryId}
            />
          ),
        };
      })
    );
    setCategoryOptions(out);
    return out;
  };
  const ratingOptions = [
    {
      value: 0,
      label: "All",
    },
    {
      value: 5,
      label: "5 stars",
    },
    {
      value: 4,
      label: "4 stars and up",
    },
    {
      value: 3,
      label: "3 stars and up",
    },
    {
      value: 2,
      label: "2 stars and up",
    },
    {
      value: 1,
      label: "1 stars and up",
    },
  ];
  const handleSearchChange = (value: any) => setSearch(value.target.value);

  const handleCategoryChange = (value: any) => {
    setPagingForm({ ...pagingForm, CategoryId: value.value });
    setOnChanging(true);
  };

  const handleRatingChange = (value: any) => {
    setPagingForm({ ...pagingForm, Rating: value.value });
    setOnChanging(true);
  };

  const handleSubmitSearch = () => {
    setPagingForm({ ...pagingForm, Search: search });
    setOnChanging(true);
  };
  useEffect(() => {
    setDefaultCategoryOption(categoryOptions.find(
      (c: any) => c.value == pagingForm.CategoryId
    ))
  }, [pagingForm.CategoryId])
  console.log(defaultCategoryOption)
  return (
    <div className="table-filter">
      <div className="filter-group">
        <div className="filter-name">
          <h5>Search</h5>
        </div>
        <div className="filter-section">
          <input
            type="search"
            value={search}
            className="form-control rounded"
            placeholder="Search"
            aria-label="Search"
            aria-describedby="search-addon"
            onChange={handleSearchChange}
          />
        </div>
      </div>
      <Button variant="secondary" onClick={handleSubmitSearch}>
        Search
      </Button>
      <hr />
      <div className="filter-group">
        <div className="filter-name">
          <h5>Category</h5>
        </div>
        <div className="filter-section">
          <AsyncSelect
            className="filter-select"
            onChange={handleCategoryChange}
            cacheOptions
            defaultOptions
            value={defaultCategoryOption}
            loadOptions={promiseCategoryOptions}
          />
        </div>
      </div>
      <hr />
      <div className="filter-group">
        <div className="filter-name">
          <h5>Rating</h5>
        </div>
        <div className="filter-section">
          <Select
            className="filter-select"
            onChange={handleRatingChange}
            defaultValue={ratingOptions[0]}
            options={ratingOptions}
          />
        </div>
      </div>
      <hr />
    </div>
  );
};
export default TableFilter;
