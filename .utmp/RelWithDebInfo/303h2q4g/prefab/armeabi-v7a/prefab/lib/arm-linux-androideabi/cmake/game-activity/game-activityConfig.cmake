if(NOT TARGET game-activity::game-activity)
add_library(game-activity::game-activity STATIC IMPORTED)
set_target_properties(game-activity::game-activity PROPERTIES
    IMPORTED_LOCATION "/Users/nasir41/.gradle/caches/transforms-3/433d5246142d5dcc6d7e9ecc2f62bb01/transformed/jetified-games-activity-2.0.2/prefab/modules/game-activity/libs/android.armeabi-v7a/libgame-activity.a"
    INTERFACE_INCLUDE_DIRECTORIES "/Users/nasir41/.gradle/caches/transforms-3/433d5246142d5dcc6d7e9ecc2f62bb01/transformed/jetified-games-activity-2.0.2/prefab/modules/game-activity/include"
    INTERFACE_LINK_LIBRARIES ""
)
endif()

if(NOT TARGET game-activity::game-activity_static)
add_library(game-activity::game-activity_static STATIC IMPORTED)
set_target_properties(game-activity::game-activity_static PROPERTIES
    IMPORTED_LOCATION "/Users/nasir41/.gradle/caches/transforms-3/433d5246142d5dcc6d7e9ecc2f62bb01/transformed/jetified-games-activity-2.0.2/prefab/modules/game-activity_static/libs/android.armeabi-v7a/libgame-activity_static.a"
    INTERFACE_INCLUDE_DIRECTORIES "/Users/nasir41/.gradle/caches/transforms-3/433d5246142d5dcc6d7e9ecc2f62bb01/transformed/jetified-games-activity-2.0.2/prefab/modules/game-activity_static/include"
    INTERFACE_LINK_LIBRARIES ""
)
endif()
