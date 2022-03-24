import axios from 'axios'
import { Host } from "../../constants";
const API_URL = Host.API;
export const setAuthHeader = (token: string|null) => {
  axios.defaults.headers.common['Authorization'] = token ? 'Bearer ' + token : ''
}
export default axios.create({
  baseURL: API_URL
})
