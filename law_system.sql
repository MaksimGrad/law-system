-- phpMyAdmin SQL Dump
-- version 4.8.3
-- https://www.phpmyadmin.net/
--
-- Хост: 127.0.0.1:3306
-- Время создания: Окт 30 2019 г., 12:35
-- Версия сервера: 5.6.41
-- Версия PHP: 5.5.38

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База данных: `law_system`
--

-- --------------------------------------------------------

--
-- Структура таблицы `authorization`
--

CREATE TABLE `authorization` (
  `id` int(11) UNSIGNED NOT NULL,
  `login` varchar(15) NOT NULL,
  `password` varchar(15) NOT NULL,
  `id_lawyer` int(11) UNSIGNED DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `authorization`
--

INSERT INTO `authorization` (`id`, `login`, `password`, `id_lawyer`) VALUES
(0, 'makson', '22101998', NULL),
(1, 'paulyuk', 'pashtet228', 1),
(2, 'lisichka', '2707007', 2),
(3, 'lagosh', '228228', 3),
(4, 'kvitok', '7776663', 4),
(5, 'zubr', '1111', 5),
(6, 'romashka', '12345678', 6),
(7, 'kuvalda', '1999', 7),
(8, 'zhuravl', 'zhur1234', 8),
(9, 'parastaev', 'rastok777', 9),
(10, 'gavrilov', 'gavril567', 10),
(11, 'tumanov', 'tuman444', 11),
(12, 'volodin', 'volod2212', 12),
(13, 'ryabov', 'ryab3490', 13),
(14, 'starostin', 'starosta2233', 14);

-- --------------------------------------------------------

--
-- Структура таблицы `clients`
--

CREATE TABLE `clients` (
  `id` int(11) UNSIGNED NOT NULL,
  `surname` varchar(20) NOT NULL,
  `name` varchar(20) NOT NULL,
  `second_name` varchar(20) NOT NULL,
  `phone` varchar(20) NOT NULL,
  `id_lawyer` int(11) UNSIGNED DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `clients`
--

INSERT INTO `clients` (`id`, `surname`, `name`, `second_name`, `phone`, `id_lawyer`) VALUES
(1, 'Лебедев', 'Сергей', 'Петрович', '23-43-45', 3),
(2, 'Данилов', 'Дмитрий', 'Валерьевич', '62-47-41', 7),
(3, 'Вилимович', 'Татьяна', 'Викторовна', '38-26-37', 1),
(4, 'Порывкина', 'Елена', 'Степановна', '28-54-28', 2),
(5, 'Вьялков', 'Василий', 'Андреевич', '26-34-79', 6),
(6, 'Мулеев', 'Егор', 'Максимович', '27-45-34', 5),
(7, 'Козьмина', 'Арина', 'Антоновна', '12-23-45', 4),
(8, 'Пидручный', 'Егор', 'Александрович', '31-78-56', 1),
(9, 'Мартынкин', 'Владимир', 'Викторович', '34-45-56', 8),
(10, 'Рудаков', 'Александр', 'Степанович', '19-10-23', 9),
(11, 'Кадышева', 'Надежда', 'Андреевна', '10-20-30', 10),
(12, 'Ветхов', 'Александр', 'Владимирович', '29-34-10', 11),
(13, 'Аллегрова', 'Ирина', 'Брониславовна', '42-12-56', 12),
(14, 'Поскряков', 'Юрий', 'Павлович', '45-10-39', 13),
(15, 'Вирер', 'Даратея', 'Витальевна', '30-23-49', 14),
(16, 'Кутаев', 'Сергей', 'Викторович', '28-31-56', NULL);

-- --------------------------------------------------------

--
-- Структура таблицы `fees`
--

CREATE TABLE `fees` (
  `id` int(11) UNSIGNED NOT NULL,
  `sum` int(11) NOT NULL,
  `id_lawyer` int(11) UNSIGNED DEFAULT NULL,
  `id_cause` int(11) UNSIGNED DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `fees`
--

INSERT INTO `fees` (`id`, `sum`, `id_lawyer`, `id_cause`) VALUES
(1, 300, 3, 1),
(2, 350, 7, 2),
(3, 370, 1, 3),
(4, 400, 1, 4),
(5, 360, 2, 5),
(6, 420, 6, 6),
(7, 320, 5, 7),
(8, 340, 4, 8),
(9, 330, 8, 9),
(10, 350, 9, 10),
(11, 310, 10, 11),
(12, 410, 11, 12),
(13, 340, 12, 13),
(14, 400, 13, 14),
(15, 370, 14, 15),
(16, 390, NULL, 16);

-- --------------------------------------------------------

--
-- Структура таблицы `finished_causes`
--

CREATE TABLE `finished_causes` (
  `id_cause` int(11) UNSIGNED NOT NULL,
  `max_term` int(3) UNSIGNED NOT NULL,
  `min_term` int(3) UNSIGNED NOT NULL,
  `received_term` int(3) UNSIGNED NOT NULL,
  `excuses` varchar(100) NOT NULL,
  `suspended_sentence` int(3) UNSIGNED NOT NULL,
  `fines` int(10) UNSIGNED NOT NULL,
  `date_cause` varchar(20) NOT NULL,
  `description` varchar(200) NOT NULL,
  `id_client` int(11) UNSIGNED DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `finished_causes`
--

INSERT INTO `finished_causes` (`id_cause`, `max_term`, `min_term`, `received_term`, `excuses`, `suspended_sentence`, `fines`, `date_cause`, `description`, `id_client`) VALUES
(1, 3, 1, 2, 'Подсудимый находился в состоянии алкогольного опьянения', 0, 200, '02.04.2018', 'Кража спиртных напитков на сумму 200 бел рублей в магазине Дионис', 1),
(2, 3, 0, 1, 'Защищал девушку', 0, 500, '10.04.2018', 'Защищал девушку от словесных нападок другого. Удары привели к сотрясению мозга и перелому рук', 2),
(3, 15, 6, 10, 'Убийство по неосторожности', 0, 2000, '05.05.2018', 'Виновный на стрельбище во время тренировки выстрелил потерпевшему в область сердца, что повлекло за собой смерть', 3),
(4, 1, 0, 0, 'Порвался ошейник', 1, 1500, '10.05.2018', 'Собака обвиняемого покусала ребенка, который сейчас находится в реанимации', 8),
(5, 20, 15, 18, 'Обвиняемый является подростком', 0, 5000, '26.05.2018', 'Обвиняемый заживо закопал потерпевшего, предварительно избив его', 4),
(6, 3, 1, 2, 'Погоня за хайпом', 0, 300, '22.06.2018', 'Обыиняемый оскорбил чувства верующих тем, что вел себя неподобающе в церкви', 5),
(7, 1, 0, 0, 'Находился в состоянии алкогольного опьянения', 1, 20, '11.07.2018', 'Обвиняемый серьезно избил одноклассника, доведя товарища до бессознательного состояния', 6),
(8, 0, 0, 0, 'Собака непослушная', 0, 200, '28.07.2018', 'Собака подсудимой нагадила на капоте автомобиля потерпевшей', 7),
(9, 1, 0, 0, 'Нет', 1, 300, '31.07.2018', 'Обвиняемый украл сумочку у пострадавшей, когда та стояла на остановке и ожидала автобус', 9),
(10, 6, 4, 6, 'Нет', 0, 10000, '09.08.2018', 'На протяжении длительного промежутка времени подсудимый брал кредиты на крупные суммы, подделывая документы', 10),
(11, 0, 0, 0, 'Нет', 0, 400, '29.08.2018', 'Подсудимая своровала музыкальную композицию у группы Кувалда', 11),
(12, 1, 0, 0, 'Алкогольная зависимость', 1, 200, '03.09.2018', 'Подсудимый дебоширит, на него постоянно поступают жалобы от жильцов дома', 12),
(13, 2, 1, 0, 'Нет', 2, 100, '10.09.2018', 'Возглавила митинг, направленый на свержение власти', 13),
(14, 3, 1, 2, 'Относительна небольшая сумма взятки', 0, 400, '18.10.2018', 'Попытка дачи взятки должностному лицу', 14),
(15, 4, 2, 4, 'Нет', 0, 500, '22.11.2018', 'Обвиняемая пернула ножом в живот своего кумира, приревновав его к фанаткам ', 15),
(16, 8, 5, 6, 'Из-за габаритов автомобиля была плохая видимость', 0, 3000, '05.12.2018', 'Обвинямый на фуре сбил женщину, сдавав задним ходом. Женщину полностью парализовало', 16);

-- --------------------------------------------------------

--
-- Структура таблицы `lawyers`
--

CREATE TABLE `lawyers` (
  `id_lawyer` int(11) UNSIGNED NOT NULL,
  `surname` varchar(30) NOT NULL,
  `name` varchar(30) NOT NULL,
  `second_name` varchar(30) NOT NULL,
  `phone` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `lawyers`
--

INSERT INTO `lawyers` (`id_lawyer`, `surname`, `name`, `second_name`, `phone`) VALUES
(1, 'Деревяга', 'Паша', 'Владимирович', '3-22-45'),
(2, 'Скрабатун', 'Дмитрий', 'Григорьевич', '3-22-34'),
(3, 'Лагош', 'Денис', 'Петрович', '3-33-33'),
(4, 'Квитка', 'Дмитрий', 'Валерьевич', '3-12-35'),
(5, 'Зубрицкая', 'Яна', 'Владимировна', '3-34-12'),
(6, 'Крутько', 'Ангелина', 'Степановна', '3-13-33'),
(7, 'Любавин', 'Дмитрий', 'Викторович', '3-22-11'),
(8, 'Журавлев', 'Игорь', 'Андреевич', '3-45-27'),
(9, 'Парастаев', 'Олег', 'Викторович', '3-75-89'),
(10, 'Гаврилов', 'Константин', 'Олегович', '3-12-34'),
(11, 'Туманов', 'Андрей', 'Юрьевич', '3-66-33'),
(12, 'Володин', 'Сергей', 'Павлович', '3-31-12'),
(13, 'Рябов', 'Владимир', 'Андреевич', '3-19-87'),
(14, 'Старостин', 'Сергей', 'Николаевич', '3-56-78');

-- --------------------------------------------------------

--
-- Структура таблицы `reports`
--

CREATE TABLE `reports` (
  `id_report` int(11) UNSIGNED NOT NULL,
  `description` varchar(900) NOT NULL,
  `year` int(4) NOT NULL,
  `id_lawyer` int(11) UNSIGNED DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `reports`
--

INSERT INTO `reports` (`id_report`, `description`, `year`, `id_lawyer`) VALUES
(1, 'На протяжении года у адвоката было 2 дела, одно из которых закончилось успешно (клиент остался на свободе), а другое завершилось менее удачно (клиент сел в тюрьму на 10 лет из 15 возможных). В целом год можно считать относительно удачным.', 2018, 1),
(2, 'На протяжении года у адвоката было одно дело, которое завершилось для клиента условным наказанием сроком на 1 год из 1 возможного. Работу адвоката следует считать неудовлетворительной.', 2018, 2),
(3, 'На протяжении года у адвоката было одно дело, которое завершилось для клиента уголовным сроком на 2 года из 3 возможных. Работу адвоката следует считать относительно нормальной.', 2018, 3),
(4, 'На протяжении года у адвоката было одно дело, которое завершилось для клиента штрафом без условного срока. Работу адвоката следует считать удовлетворительной.', 2018, 4),
(5, 'На протяжении года у адвоката было одно дело, которое завершилось для клиента условным сроком на 1 год из 1 возможного. Работу адвоката следует считать неудовлетворительной.', 2018, 5),
(6, 'На протяжении года у адвоката было одно дело, которое завершилось для клиента уголовным сроком на 2 года из 3 возможных. Работу адвоката следует считать относительно нормальной.', 2018, 6),
(7, 'На протяжении года у адвоката было одно дело, которое завершилось для клиента уголовным сроком на 1 год из 3 возможных. Работу адвоката следует считать относительно нормальной.', 2018, 7),
(8, 'На протяжении года у адвоката было одно дело, которое завершилось для клиента условным сроком на 1 год из 1 возможного. Работу адвоката следует считать неудовлетворительной.', 2018, 8),
(9, 'На протяжении года у адвоката было одно дело, которое завершилось для клиента условным сроком на 6 лет из 6 возможных. Работу адвоката следует считать неудовлетворительной.', 2018, 9),
(10, 'На протяжении года у адвоката было одно дело, которое завершилось для клиента штрафом на сумму 400 бел рублей. Работу адвоката следует считать относительно нормальной.', 2018, 10),
(11, 'На протяжении года у адвоката было одно дело, которое завершилось для клиента условным сроком на 1 год из 1 возможного. Работу адвоката следует считать неудовлетворительной.', 2018, 11),
(12, 'На протяжении года у адвоката было одно дело, которое завершилось для клиента условным сроком на 2 года из 2 возможных. Работу адвоката следует считать неудовлетворительной.', 2018, 12),
(13, 'На протяжении года у адвоката было одно дело, которое завершилось для клиента уголовным сроком на 2 года из 3 возможных. Работу адвоката следует считать относительно нормальной.', 2018, 13),
(14, 'На протяжении года у адвоката было одно дело, которое завершилось для клиента уголовным сроком на 4 года из 4 возможных. Работу адвоката следует считать неудовлетворительной.', 2018, 14),
(15, 'На протяжении года у адвоката было одно дело, которое завершилось для клиента уголовным сроком на 6 лет из 8 возможных. Работу адвоката следует считать относительно нормальной.', 2018, NULL);

-- --------------------------------------------------------

--
-- Структура таблицы `success`
--

CREATE TABLE `success` (
  `id` int(11) UNSIGNED NOT NULL,
  `efficiency` int(11) UNSIGNED NOT NULL,
  `inefficiency` int(11) UNSIGNED NOT NULL,
  `id_cause` int(11) UNSIGNED DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `success`
--

INSERT INTO `success` (`id`, `efficiency`, `inefficiency`, `id_cause`) VALUES
(1, 33, 50, 1),
(2, 67, 100, 2),
(3, 56, 44, 3),
(4, 0, 100, 4),
(5, 10, 17, 5),
(6, 33, 50, 6),
(7, 0, 100, 7),
(8, 100, 0, 8),
(9, 0, 100, 9),
(10, 0, 33, 10),
(11, 100, 0, 11),
(12, 0, 100, 12),
(13, 0, 100, 13),
(14, 33, 50, 14),
(15, 0, 50, 15),
(16, 25, 83, 16);

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `authorization`
--
ALTER TABLE `authorization`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `id_lawyer` (`id_lawyer`);

--
-- Индексы таблицы `clients`
--
ALTER TABLE `clients`
  ADD PRIMARY KEY (`id`),
  ADD KEY `lawyer_client` (`id_lawyer`);

--
-- Индексы таблицы `fees`
--
ALTER TABLE `fees`
  ADD PRIMARY KEY (`id`),
  ADD KEY `cause_id` (`id_cause`),
  ADD KEY `fee_lawyer` (`id_lawyer`);

--
-- Индексы таблицы `finished_causes`
--
ALTER TABLE `finished_causes`
  ADD PRIMARY KEY (`id_cause`),
  ADD KEY `client_case` (`id_client`);

--
-- Индексы таблицы `lawyers`
--
ALTER TABLE `lawyers`
  ADD PRIMARY KEY (`id_lawyer`);

--
-- Индексы таблицы `reports`
--
ALTER TABLE `reports`
  ADD PRIMARY KEY (`id_report`),
  ADD KEY `report_lawyer` (`id_lawyer`);

--
-- Индексы таблицы `success`
--
ALTER TABLE `success`
  ADD PRIMARY KEY (`id`),
  ADD KEY `cause_success` (`id_cause`);

--
-- Ограничения внешнего ключа сохраненных таблиц
--

--
-- Ограничения внешнего ключа таблицы `authorization`
--
ALTER TABLE `authorization`
  ADD CONSTRAINT `lawyer_pass` FOREIGN KEY (`id_lawyer`) REFERENCES `lawyers` (`id_lawyer`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Ограничения внешнего ключа таблицы `clients`
--
ALTER TABLE `clients`
  ADD CONSTRAINT `lawyer_client` FOREIGN KEY (`id_lawyer`) REFERENCES `lawyers` (`id_lawyer`) ON DELETE SET NULL ON UPDATE CASCADE;

--
-- Ограничения внешнего ключа таблицы `fees`
--
ALTER TABLE `fees`
  ADD CONSTRAINT `cause_id` FOREIGN KEY (`id_cause`) REFERENCES `finished_causes` (`id_cause`) ON DELETE SET NULL ON UPDATE CASCADE,
  ADD CONSTRAINT `fee_lawyer` FOREIGN KEY (`id_lawyer`) REFERENCES `lawyers` (`id_lawyer`) ON DELETE SET NULL ON UPDATE CASCADE;

--
-- Ограничения внешнего ключа таблицы `finished_causes`
--
ALTER TABLE `finished_causes`
  ADD CONSTRAINT `client_case` FOREIGN KEY (`id_client`) REFERENCES `clients` (`id`) ON DELETE SET NULL ON UPDATE CASCADE;

--
-- Ограничения внешнего ключа таблицы `reports`
--
ALTER TABLE `reports`
  ADD CONSTRAINT `report_lawyer` FOREIGN KEY (`id_lawyer`) REFERENCES `lawyers` (`id_lawyer`) ON DELETE SET NULL ON UPDATE CASCADE;

--
-- Ограничения внешнего ключа таблицы `success`
--
ALTER TABLE `success`
  ADD CONSTRAINT `cause_success` FOREIGN KEY (`id_cause`) REFERENCES `finished_causes` (`id_cause`) ON DELETE SET NULL ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
