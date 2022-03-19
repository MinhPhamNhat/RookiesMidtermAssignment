import { useEffect, useState } from "react";
import AsyncSelect from "react-select/async";
import Select from "react-select";
import { categoryService } from "../../services";
import Option from "../Option";
import { Category } from "../../types/model";
import "./index.css";
import { Button } from "@mui/material";

const CategoryFilter = ({ pagingForm, setPagingForm, setOnChanging }: any) => {
  const [search, setSearch] = useState("");

  const handleSearchChange = (value: any) => setSearch(value.target.value);

  const handleIsParentOptionClick = (value: any) => {
    setPagingForm({ ...pagingForm, IsParent: value });
    setOnChanging(true);
  };

  const handleSubmitSearch = () => {
    setPagingForm({ ...pagingForm, Search: search });
    setOnChanging(true);
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
            value={search}
            className="form-control rounded"
            placeholder="Search"
            aria-label="Search"
            aria-describedby="search-addon"
            onChange={handleSearchChange}
          />
        </div>
      </div>
      <Button variant="contained" color="primary" onClick={handleSubmitSearch}>
        Search
      </Button>
      <hr />
      <div className="filter-group">
        <div className="filter-name">
          <h5>Is Parent</h5>
        </div>
        <div className="filter-section">
          <Button onClick={()=>handleIsParentOptionClick(undefined)} variant="outlined" color="secondary">
            All
          </Button>
          <Button onClick={()=>handleIsParentOptionClick(true)} variant="outlined" color="success">
            Parent
          </Button>
          <Button onClick={()=>handleIsParentOptionClick(false)} variant="outlined" color="primary">
            Children
          </Button>
        </div>
        <hr />
      </div>
    </div>
  );
};
export default CategoryFilter;
