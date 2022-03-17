import { useState } from "react";
import AsyncSelect from "react-select/async";
import Select from "react-select";
import { categoryService } from "../../services";
import Option from "../../components/Option";
import "./index.css";
import { Category } from "../../types/model";
import { Button } from "react-bootstrap";
const TableFilter = ({ products }: any) => {
  const [categoryId, setCategoryId] = useState(0);

  const promiseCategoryOptions = async () => {
    var data = (await categoryService.getCategories()).data;
    return data.map((c: Category) => {
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
    });
  };
  return (
    <div className="table-filter">
      <div className="filter-group">
        <div className="filter-name">
          <h5>Search</h5>
        </div>
        <div className="filter-section">
          <input
            type="search"
            className="form-control rounded"
            placeholder="Search"
            aria-label="Search"
            aria-describedby="search-addon"
          />
        </div>
      </div>
      <Button variant="secondary">Search</Button>
      <hr />
      <div className="filter-group">
        <div className="filter-name">
          <h5>Category</h5>
        </div>
        <div className="filter-section">
          <AsyncSelect
            className="filter-select"
            onChange={(value: any) => setCategoryId(value.value)}
            cacheOptions
            defaultOptions
            loadOptions={promiseCategoryOptions}
          />
        </div>
      </div>
      <hr />
    </div>
  );
};
export default TableFilter;
