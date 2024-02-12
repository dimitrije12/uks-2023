import { request } from './http.service';

export const userService = {
  async login(user) {
    return request('post', '/api/auth/login', {
      user,
    });
  },
};
