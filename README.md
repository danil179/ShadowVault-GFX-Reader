# ShadowVault-GFX-Reader
This is a decoder in C# for (some) the game files of Shadow Vault (http://www.strategyinformer.com/pc/shadowvault/). I originally published it in https://forum.xentax.com/viewtopic.php?t=11039 but as the forum may close in the future (ZenHAX got closed recently), I decided to republish it here.

# Before running: Decryption & Extraction #
Use QuickBMS software (http://aluigi.altervista.org/quickbms.htm) and the scripts provided in the repository to extract and decrypt the .dat files as follows:
1. The .dat archives encrypted so you need to decrypt them using the script "type_dat_decoder.bms"
2. Extract the decrypted archive using "type_dat_extractor.bms"
3. (OPTIONAL: Extract the .gxl files using "type_gxl_extractor.bms". However, the reader is now compatible for reading those files.)

# Using the program #
Compile the C# project GFXViewer. You can now read .gxl files of the ShadowVault game and present them.

# TODO
* Add more file formats

# Acknowledgments #
I thank Luigi Auriemma for the excellent QuickBMS software that allows us to easily construct scripts for decryption/extraction. Also, I used LZRW1KH decompressor (LZRW1KH.cs file) implementation provided by @vhanla (https://github.com/vhanla) under the MIT license (https://github.com/vhanla/lzrw1), thanks to the brilliant implementation I was able to decode the textures. In this file you can find the notice of the MIT license as per the license requirements.

To decode the IMA ADPCM audio data I used https://github.com/Kalmalyzer/adpcm-68k program ADPCMCodec.exe included here. It is under the MIT License as follows:
MIT License

Copyright (c) 2023 Mikael Kalms

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

