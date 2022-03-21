import { Product } from "../../../types/model"

const NameCell = ({ product }: any) =>{
    return <span title={product.Name}>{product.Name}</span>
}
export default NameCell