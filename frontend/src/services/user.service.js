import { request } from './http.service';

export const userService = {
  async login(user) {
    return request(
      'post',
      `/api/Users/login?username=${user?.username}&password=${user?.password}`,
      {}
    );
  },
};
