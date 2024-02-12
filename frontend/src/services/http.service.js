import axios from 'axios';
import { localStorageService } from './localStorage.service';
import { backendUrl } from '@/environment';

axios.interceptors.response.use(
  (response) => {
    return response;
  },
  async (error) => {
    handleError(error);
    return Promise.reject(error);
  }
);

const handleError = async (err) => {
  console.log(err);
  // TODO:
};

const request = async (method, apiUrl, body, headers) => {
  try {
    const requestHeaders = !headers ? {} : headers;
    const username = localStorageService.get('username');
    const accessToken = localStorageService.getAccessToken(username);
    const refreshToken = localStorageService.getRefreshToken(username);

    if (accessToken) requestHeaders['x-access-token'] = accessToken;
    if (refreshToken) requestHeaders['x-refresh-access-token'] = refreshToken;

    if (method === 'get' || method === 'delete')
      return axios[method](backendUrl + apiUrl, { headers: requestHeaders });
    else if (method === 'post' || method === 'put' || method === 'patch')
      return axios[method](backendUrl + apiUrl, body, {
        headers: requestHeaders,
      });
  } catch (err) {
    handleError(err);
  }
};

export { request };
