## ExampleGameOnUnity3D
## Version: 1.0
## Language: Russian
## Adaptive-Ratio settings
## Interact with different items

В этом репозитории представлено много префабов разного вида, собранного с разных пакетов, а также продемонстрировано много ручных префабов.

Введена система квестов:
QuestItem, QuestTaker -> основопологающие скрипты, которые позволяют взаимодействовать как с кнопками, так и с бумажками, так и любым предметом.
QuestTaker -> вызывает всплывающие окно задания, когда QuestItem -> по сути является хранилищем.
Реализация проходит через вызов метода OnColliderEnter, а также насильно вызванного метода OnColliderOther (вызывается, когда не зависит от коллайдера,
а зависит от нажатия клавиши мыши, также можно комбинировать эти методы).

Если интересует отдельно персонаж, то советуем ознакомиться с PersonControllerUnity. В данном репозитории, вы сможете отдельно ознакомиться
с возможностями персонажа (также там весит заглушка квеста, со старым оформлением)
