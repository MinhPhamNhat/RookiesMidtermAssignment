import CategoryOption from "./Category";
import ColorOption from "./Color";

const Option: React.FC<any> & {
  Category: typeof CategoryOption;
  Color: typeof ColorOption;
} = ({ children }): JSX.Element => <>{children}</>;

Option.Category = CategoryOption;
Option.Color = ColorOption;

export default Option;
