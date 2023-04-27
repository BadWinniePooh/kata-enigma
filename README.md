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

- The plugboard contains a maximum of 10 connections
	- Not all connections have to be used
	- There will be at least 6 unmapped letters left and will be used unchanged
- Each connection is bidirectional
	- That means A -> B also is B -> A
	- This counts as one connection on the plugboard
- Each connection is only used once
	- That means A -> B, B -> C is not valid
	- No letter can connect to itself
- Umlauts are not considered
	- Optional you can convert Ä -> AE, Ö -> OE, Ü -> UE and ß -> SS
- If a configuration or a connection is not legitimate raise an exception	
- There is no differentiation between upper and lowercase letters
- The plugboard converts all letters from A to Z with a given configuration

<a id="part-2-one-rotor"></a>
## Part 2 - One Rotor

For the second part of this kata you have to design one rotor.
A rotor is a disk containig 26 inputs and 26 outputs. Each input and each output represents one letter.
On the input side the letters are sorted A to Z, on the output side they are configured by the user.
A configuration starting with QWE means A is converted to Q, B to W and C to E.
Since a Rotor rotates it is not that easy. Before the conversion happens the rotor has to rotate.

- Configuration for a rotor is given as a 26 letter string and one number
- The string resembles the mapping of the rotor
	- The string has to be exactly 26 letters long
	- All letters have to be unique
	- The first char always maps to A, the second to B ... and the last to Z
- The number resembles the starting position of the rotor
	- Since the rotor is one indexed 1 would be A, 2 B ... and 26 Z
	- Thus the number given has to be between 1 and 26
	- Starting number means that the letter related to the number is currently mapped to A
	- The rotor counts up and transitions from 26 to 1
	- The starting position can be changed at any time if the user wants to
- The rotation of the rotor takes place after an input is provided and before the conversion takes place	
- During the use of a rotor, the configuration may not be changed
- The user can always see the current state of the rotor as number
	- If no input has happened the starting number should be returned
- Validate the mapping, the starting position and that the mapping can't be changed
	- Raise exceptions on violations
