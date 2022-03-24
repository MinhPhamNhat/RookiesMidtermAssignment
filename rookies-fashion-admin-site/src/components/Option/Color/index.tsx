import "./index.css";
import { components } from "react-select";
const ColorOption: React.FC<any> = (props) => {
  const { name, url } = props;
  return (
    <div className="color-option">
      <img src={url} /> {name}
    </div>
  );
};

export default ColorOption;
