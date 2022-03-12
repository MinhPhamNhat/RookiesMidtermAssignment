import axios from 'axios'
import { Host } from "../../constants";
const API_URL = Host.API;
export default axios.create({
  baseURL: API_URL
})
