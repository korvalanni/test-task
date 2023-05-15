# test-task
Тестовое задание в летнюю школу  UCSB

Необходимо разработать класс (либо RESTful сервис), предоставляющий интерфейс

• Создать именованную колоду карт (колода создаётся упорядоченной)

• Удалить именованную колоду

• Получить список названий колод

• Перетасовать колоду

• Получить колоду по имени (в её текущем упорядоченном/перетасованном состоянии)

Необходимо спроектировать интерфейсы так, чтобы алгоритм перетасовки мог задаваться через
конфигурацию приложения (путём выбора из «простой» и «эмуляция перетасовки вручную»).
Необходимо самостоятельно спроектировать API для колоды и все типы данных.

Примечания:
• Колоды достаточно хранить в памяти, но подумать о том, как впоследствии работать с БД.
• Реализацию достаточно сделать для стандартной колоды игральных карт (52 штуки), но
будет плюсом при решении помнить о том, что сортировщику карт всё равно, какую
колоду тасовать.
• Алгоритм перетасовки достаточно реализовать «простой» (любой, самый быстрый в
реализации); при желании можно реализовать «эмуляцию перетасовки вручную» (колода
делится примерно посередине, части меняются местами, и так много раз).

При отправке решения, укажите, пожалуйста, сколько времени было потрачено

Разместите ссылку на Ваше решение в GitHub или GitLab

В качестве тестового реализован сервис на базе asp.netcore с использоваением библиотек:
MediatR, Swagger, FluentValidations, Tests: FluentAssertations (не успела покрытие на интеграционном уровне)
AspNetCore.
В качестве решения предлагаются 4 метода RestApi:
1. Создание Колоды из 32 или 54 карт  с опредленным именем
2. Получение текущего состояния колоды карт на основе состояния памяти  прилоежния
3. Перемешивание карт путем мануальной настройки (задаются места, где колода делится пополам и правая с левой частью меняются)
4. Мермешивание карт путем случайной генерации
Для запросов и ответов используются dto в виде record-ов

На решение было потрачено 5 часов
Используются дженерики, интерфейсы, мидлвары, фабрики и другие популярные способы решения проблем при написании крупных приложений
