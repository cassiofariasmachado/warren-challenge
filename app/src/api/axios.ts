import axios, { AxiosInstance } from 'axios';
import config from '../config';

export const createInstace = (): AxiosInstance =>
    axios.create({ baseURL: config.apiUrl, timeout: 5000 });

