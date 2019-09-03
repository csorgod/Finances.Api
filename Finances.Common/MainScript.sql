/* Useful commands
SET SQL_SAFE_UPDATES = 0;
*/

SET SQL_SAFE_UPDATES = 0;

CREATE SCHEMA finances;

use finances;

create table `finances`.`person`
(
	`id` varchar(36) not null primary key,
    `first_name` varchar(20) not null,
    `last_name` varchar (50) not null,
    `age` int(2) not null,
    `tax_number` varchar(14) not null,
    `gender` char(1),
    `created_date` timestamp default current_timestamp not null,
    `updated_date` timestamp default current_timestamp not null,
    unique(`tax_number`)
);

create table `finances`.`user`
(
	`id` varchar(36) not null primary key,
    `username` varchar(40) not null,
    `password` varchar(256) not null,
    `status` int(1) not null,
    `created_date` timestamp default current_timestamp not null,
    `updated_date` timestamp default current_timestamp not null,
    unique(`username`)
);

create table `finances`.`user_image`
(
	`id` varchar(36) not null primary key,
    `user_id` varchar(36) not null,
    constraint `fk_user_image_user_id` foreign key(`user_id`) references `finances`.`user`(`id`),
    `path` varchar(500) not null,
    `created_date` timestamp default current_timestamp not null,
    `updated_date` timestamp default current_timestamp not null
);

create table `finances`.`user_has_person`
(
	`id` varchar(36) not null primary key,
    `user_id` varchar(36) not null,
    constraint `fk_user_has_person_user_id` foreign key(`user_id`) references `finances`.`user`(`id`),
    `person_id` varchar(36) not null,
    constraint `fk_user_has_person_person_id` foreign key(`person_id`) references `finances`.`person`(`id`),
    `created_date` timestamp default current_timestamp not null,
    `updated_date` timestamp default current_timestamp not null
);

create table `finances`.`contact`
(
	`id` varchar(36) not null primary key,
    `phone_number` varchar(13),
    `email` varchar(13) not null,
    `created_date` timestamp default current_timestamp not null,
    `updated_date` timestamp default current_timestamp not null,
    unique(`email`)
);

create table `finances`.`person_has_contact`
(
	`id` varchar(36) not null primary key,
    `person_id` varchar(36) not null,
    constraint `fk_person_has_contact_person_id` foreign key(`person_id`) references `finances`.`person`(`id`),
    `contact_id` varchar(36) not null,
    constraint `fk_person_has_contact_contact_id` foreign key(`contact_id`) references `finances`.`contact`(`id`),
    `created_date` timestamp default current_timestamp not null,
    `updated_date` timestamp default current_timestamp not null
);

CREATE TABLE `finances`.`login_jwt` (
  `id` varchar(36) not null primary key,
  `user_id` varchar(36) not null,
  constraint `fk_login_jwt_user_id` foreign key(`user_id`) references `finances`.`user`(`id`),
  `header` varchar(1000) not null,
  `payload` varchar(1000) not null,
  `signature` varchar(1000) not null,
  `status` int(1) not null,
  `expire_date` timestamp null default null,
  `created_date` timestamp default current_timestamp not null,
  `updated_date` timestamp default current_timestamp not null
);

CREATE TABLE `finances`.`favored`
(
	`id` varchar(36) not null primary key,
    `belongs_to_user_id` varchar(36) not null,
    constraint `fk_favored_user_id` foreign key(`belongs_to_user_id`) references `finances`.`user`(`id`),
    `name` varchar(50) not null,
    `tax_number` varchar(14) not null,
    `status` int(1) not null,
    `created_date` timestamp default current_timestamp not null,
    `updated_date` timestamp default current_timestamp not null
);

CREATE TABLE `finances`.`account`
(
	`id` varchar(36) not null primary key,
    `bank` int(6) not null,
    `bank_branch` int(4) not null,
    `bank_account` int(10) not null,
    `bank_account_digit` int(2) not null,
    `status` int(1) not null,
    `account_type` int(1) not null,
    `created_date` timestamp default current_timestamp not null,
    `updated_date` timestamp default current_timestamp not null
);

CREATE TABLE `finances`.`user_has_account`
(
	`id` varchar(36) not null primary key,
    `user_id` varchar(36) not null,
	constraint `fk_user_has_account_user_id` foreign key(`user_id`) references `finances`.`user`(`id`),
    `account_id` varchar(36) not null,
    constraint `fk_user_has_account_account_id` foreign key(`account_id`) references `finances`.`account`(`id`),
    `created_date` timestamp default current_timestamp not null,
    `updated_date` timestamp default current_timestamp not null
);

CREATE TABLE `finances`.`favored_has_account`
(
	`id` varchar(36) not null primary key,
    `favored_id` varchar(36) not null,
	constraint `fk_favored_has_account_favored_id` foreign key(`favored_id`) references `finances`.`favored`(`id`),
    `account_id` varchar(36) not null,
    constraint `fk_favored_has_account_account_id` foreign key(`account_id`) references `finances`.`account`(`id`),
    `created_date` timestamp default current_timestamp not null,
    `updated_date` timestamp default current_timestamp not null
);

CREATE TABLE `finances`.`card`
(
	`id` varchar(36) not null primary key,
    `person_id` varchar(36) not null,
    constraint `fk_card_person_id` foreign key(`person_id`) references `finances`.`person`(`id`),
    `type` int(1) not null,
    `holder` varchar(30) not null,
    `number` varchar(16) not null,
    `expire_date` timestamp not null,
    `created_date` timestamp default current_timestamp not null,
    `updated_date` timestamp default current_timestamp not null	
);

CREATE TABLE `finances`.`incoming`
(
	`id` varchar(36) not null primary key,
    `person_id` varchar(36) not null,
    constraint `fk_incoming_person_id` foreign key(`person_id`) references `finances`.`person`(`id`),
    `income_type` int(1) not null, -- fixa, variável (frequencia irregular), avulsa, etc
    `name` varchar(30) not null,
    `description` varchar(1000),
    `value` double not null,
    `status` int(1) not null,
    `receive_at` timestamp default null,
    `recurrent` boolean default null,
    `created_date` timestamp default current_timestamp not null,
    `updated_date` timestamp default current_timestamp not null
);

CREATE TABLE `finances`.`bills_to_pay`
(
	`id` varchar(36) not null primary key,
    `person_id` varchar(36) not null,
    constraint `fk_bills_to_pay_person_id` foreign key(`person_id`) references `finances`.`person`(`id`),
    `type` int(1) not null,
    `value` double not null,
    `expiration_date` timestamp not null,
    `created_date` timestamp default current_timestamp not null,
    `updated_date` timestamp default current_timestamp not null
);