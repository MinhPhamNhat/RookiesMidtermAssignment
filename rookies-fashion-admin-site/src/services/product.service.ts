import HttpClient from '../utils/HttpClient'
import { Endpoints} from '../constants'
class ProductService{
    async getProducts(){
        const endpoint = Endpoints.PRODUCTS;
        const response = await HttpClient.get(endpoint)
        return response
    }

    async getProductById(id: string){
        const endpoint = Endpoints.PRODUCTS + `/${id}`;
        const response = await HttpClient.get(endpoint)
        return response
    }

    async updateProduct(id: string){
        const endpoint = Endpoints.PRODUCTS + `/${id}`;
        const response = await HttpClient.get(endpoint)
        return response
    }
}

export default new ProductService()