import { AppState } from "../AppState"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"
import { profilesService } from "./ProfilesService"

class FollowsService {
  async createFollow(data) {
    const res = await api.post('api/follows', data)
    logger.log('[createFollow]', res.data)
    await profilesService.getProfiles(AppState.account.id)

  }
  async deleteFollow(followingId) {
    const follow = AppState.myProfile.following.find(f => f.id == followingId)
    const res = await api.delete(`api/follows/${follow.followId}`)
    logger.log('[deleteFollow]', res.data)
    await profilesService.getProfiles(AppState.account.id)

  }
}
export const followsService = new FollowsService()