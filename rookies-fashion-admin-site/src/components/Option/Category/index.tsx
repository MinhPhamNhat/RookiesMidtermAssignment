import "./index.css";
import { components } from "react-select";
const CategoryOption: React.FC<any> = (props) => {
  const { name, isParent} = props;
  return (
    <div className={isParent?"parent-option":"child-option"}>
      {name}
    </div>);
};

export default CategoryOption;
