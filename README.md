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
The plugboard is used to setup a mapping of the alphabet. It sets up a bidirectional mapping of a subset of letters. Unmapped letters are handled as if they connect to themselves. This is done the following way.

- The plugboard contains a maximum of 10 connections
	- Not all connections have to be used
	- There will be at least 6 unconnected letters left and need to be mapped automatically
- Each connection is bidirectional
	- That means A -> B also is B -> A
	- This example counts as one connection on the plugboard
- Each letter can only be connected to one other letter
	- That means A -> B, B -> C is not valid
	- No letter can be configured to connect to itself
- If the configuration of the plugboard is not legitimate raise an exception	
- There is no differentiation between upper and lowercase letters
- The plugboard encrypts all 26 letters of the alphabet with a given configuration

<a id="part-2-one-rotor"></a>
## Part 2 - One Rotor
For the second part of this kata you have to design one rotor.
A rotor is a disk containig 26 inputs and 26 outputs.
