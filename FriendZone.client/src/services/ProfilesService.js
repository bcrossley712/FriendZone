import { AppState } from "../AppState"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"

class ProfilesService {
  async getProfiles(userId) {
    const res = await api.get('api/profiles')
    logger.log('[getProfiles]', res.data)
    AppState.profiles = res.data.filter(p => p.id != userId)
    AppState.myProfile = res.data.find(p => p.id == userId)
  }
  async getMyFollowing(userId) {
    const res = await api.get(`api/profiles/${userId}/following`)
    logger.log('[getMyFollowing]', res.data)
    AppState.following = res.data
  }
  async getMyFollowers(userId) {
    const res = await api.get(`api/profiles/${userId}/followers`)
    logger.log('[getMyFollowers]', res.data)
    // AppState.followers = res.data

    return res.data
  }
}
export const profilesService = new ProfilesService()