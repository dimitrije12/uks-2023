export const localStorageService = {
  delete(type) {
    localStorage.removeItem(type);
  },

  set(type, data) {
    localStorage.setItem(type, JSON.stringify(data));
  },

  get(type) {
    const data = localStorage.getItem(type);
    if (!data) return null;
    const res = JSON.parse(data);
    return res;
  },

  getAccessToken(username) {
    const token = localStorage.getItem(`accessToken_${username}`);
    return token;
  },

  setAccessToken(username, token) {
    if (!token) return;
    localStorage.setItem(`accessToken_${username}`, token);
  },

  getRefreshToken(username) {
    const token = localStorage.getItem(`refreshToken_${username}`);
    return token;
  },

  setRefreshToken(username, token) {
    if (!token) return;
    localStorage.setItem(`refreshToken_${username}`, token);
  },
};
