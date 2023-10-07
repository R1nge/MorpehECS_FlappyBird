using FlappyBird.Code.Collision;
using FlappyBird.Code.GameFlow;
using FlappyBird.Code.Obstacle.Collision;
using FlappyBird.Code.Obstacle.Movement;
using FlappyBird.Code.Player.Movement;
using FlappyBird.Code.Score;
using FlappyBird.Code.Sound;
using FlappyBird.Code.UI;
using Scellecs.Morpeh;
using UnityEngine;

namespace FlappyBird.Code
{
    public class EcsBootstrap : MonoBehaviour
    {
        [Header("GamePlay")] 
        [Header("Initializers")] 
        [SerializeField] private CollisionInitSystem collisionInitSystem;
        [SerializeField] private PlayerMovementInitSystem playerMovementInitSystem;
        [SerializeField] private ObstacleMovementInitSystem obstacleMovementInitSystem;
        [SerializeField] private ScoreInitSystem scoreInitSystem;

        [Header("Update Systems")] 
        [SerializeField] private ObstacleHitSystem obstacleHitSystem;
        [SerializeField] private ScoreHitSystem scoreHitSystem;
        [SerializeField] private ScoreSystem scoreSystem;
        [SerializeField] private ScoreIncreaseSoundSystem scoreIncreaseSoundSystem;
        [SerializeField] private ObstacleMovementSystem obstacleMovementSystem;
        [SerializeField] private PlayerMovementInputSystem playerMovementInputSystem;
        [SerializeField] private PlayerMovementSystem playerMovementSystem;
        [SerializeField] private GameOverSystem gameOverSystem;
        [SerializeField] private ScoreSaveSystem scoreSaveSystem;

        [Header("Cleanup Systems")] 
        [SerializeField] private CollisionCleanSystem collisionCleanSystem;
        [SerializeField] private GameOverCleanSystem gameOverCleanSystem;
        [SerializeField] private ScoreEventCleanSystem scoreEventCleanSystem;

        [Header("UI")] 
        [Header("Update Systems")] 
        [SerializeField] private GameOverScreenSystem gameOverScreenSystem;
        [SerializeField] private GamePlayScreenSystem gamePlayScreenSystem;
        
        private SystemsGroup _gamePlaySystemGroup;
        private SystemsGroup _uiSystemGroup;

        private void Start() => InitSystems();

        private void InitSystems()
        {
            _gamePlaySystemGroup = World.Default.CreateSystemsGroup();
            _gamePlaySystemGroup.AddInitializer(collisionInitSystem);
            _gamePlaySystemGroup.AddInitializer(playerMovementInitSystem);
            _gamePlaySystemGroup.AddInitializer(obstacleMovementInitSystem);
            _gamePlaySystemGroup.AddInitializer(scoreInitSystem);
            _gamePlaySystemGroup.AddSystem(obstacleHitSystem);
            _gamePlaySystemGroup.AddSystem(scoreHitSystem);
            _gamePlaySystemGroup.AddSystem(scoreSystem);
            _gamePlaySystemGroup.AddSystem(scoreIncreaseSoundSystem);
            _gamePlaySystemGroup.AddSystem(obstacleMovementSystem);
            _gamePlaySystemGroup.AddSystem(playerMovementInputSystem);
            _gamePlaySystemGroup.AddSystem(playerMovementSystem);
            _gamePlaySystemGroup.AddSystem(gameOverSystem);
            _gamePlaySystemGroup.AddSystem(scoreSaveSystem);
            _gamePlaySystemGroup.AddSystem(collisionCleanSystem);
            _gamePlaySystemGroup.AddSystem(gameOverCleanSystem);
            _gamePlaySystemGroup.AddSystem(scoreEventCleanSystem);
            World.Default.AddSystemsGroup(0, _gamePlaySystemGroup);
            _uiSystemGroup = World.Default.CreateSystemsGroup();
            _uiSystemGroup.AddSystem(gameOverScreenSystem);
            _uiSystemGroup.AddSystem(gamePlayScreenSystem);
            World.Default.AddSystemsGroup(1, _uiSystemGroup);
        }

        private void OnDestroy()
        {
            World.Default.RemoveSystemsGroup(_gamePlaySystemGroup);
            World.Default.RemoveSystemsGroup(_uiSystemGroup);
            World.Default.Commit();
        }
    }
}