## Convert any binary file to hex coded file (C structure)**

**Bin2Hex** is a utility designed to convert any binary file into a hexadecimal representation formatted as a C structure. This application takes a binary file and outputs its content in a human-readable, structured format that can be easily integrated into C/C++ projects. The output includes the binary file's name, length, and the converted data as an array of unsigned characters. This tool is particularly useful for embedding binary data directly into source code, such as firmware, images, or configuration files.

Example output:

```c
//********************************************************
// Binary file converter to Hex C structure
// Version 1.00, (c) Evieplus
// Binary File Name    : Bin2Hex.exe
// Binary File Length  : 10240
//********************************************************
unsigned char ucaBin2Hex[]=
{
    0x4D, 0x5A, 0x90, 0x00, 0x03, 0x00, 0x00, 0x00, 0x04, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0x00, 0x00,
    0xB8, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x40, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
    //... additional hex data ...
};
```

This application is ideal for developers who need to include binary files directly in their source code without relying on external files at runtime.
