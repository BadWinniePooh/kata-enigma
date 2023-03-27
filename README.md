# Enigma Machine

## Introduction
The Enigma machine is a cipher device developed in the early to mid 20th century. It was mostly used by the germans during World War II.
More information on Wikipedia: https://en.wikipedia.org/wiki/Enigma_machine

## Goal
The goal of this Kata is to recreate the famous Enigma machine in multiple steps and at the end decrypt a secret message which I encrypted while developing and solving this kata on my own.

## Code Kata
information on Code Katas http://codekata.com

## Disclaimer
This is the first Code Kata I'm designing and this repo is currently work in Progress

---

# Table of Contents
1. [Part 1 - The Plugboard](#part-1-plugboard)
2. [Part 2 - One Rotor](#part-2-one-rotor)

---

# Design Parts

<a id="part-1-plugboard"></a>
## Part 1 - The Plugboard

For the first part of this kata you have to design the plugboard.
The plugboard contains all 26 letters and maps one to another.

- The plugboard contains all letters from A to Z
- There is no differentiation between upper and lowercase letters
- Umlauts are not considered Ä -> AE, Ö -> OE, Ü -> UE and ß -> SS
- The plugboard contains a maximum of 10 connections
	- Not all connections have to be used
	- There will be at least 6 unmapped letters left and will be used unchanged
- Each connection is only used once
	- That means A -> B, B -> C is not valid
	- No letter can connect to itself
- Each connection is bidirectional
	- That means A -> B also is B -> A
	- This counts as one connection on the plugboard
- If a configuration or a connection is not legitimate raise an exception

<a id="part-2-one-rotor"></a>
## Part 2 - One Rotor
For the second part of this kata you have to design one rotor.
A rotor is a disk containig 26 inputs and 26 outputs.
