Image = {
	-- Insert image data here from IMG2RBX
	
}
index = 3 -- start from 3, cause 1 & 2 define the size of the image
width = Image[1]
height = Image[2]

-- create gui stuff for it
sGui = Instance.new("ScreenGui", script.Parent)
sGui.Name = "Converted"
Canvas = Instance.new("Frame", sGui)
Canvas.Size = UDim2.new(0,width,0,height)
Canvas.Position = UDim2.new(0,0.2,0,0.2)
Canvas.Name = "Canvas"

RunNum = 1;

for i,v in pairs(Image) do -- for each pixel data in table
	pcall(function()
		local Pixel = Instance.new("Frame", Canvas) -- create new frame, this will be used as a pixel.
		Pixel.BorderSizePixel = 0
		Pixel.Size = UDim2.new(0,1,0,1)
		
		-- get what its currently on, were gonna mostly have to guess and suffer through this but yes
		-- since it started at 3, 1 2 define the size, 3 should be the X location, so 3+1 = Y location
		local X = Image[index]
		local Y = Image[index+1]
		
		local R = Image[index+2]
		local G = Image[index+3]
		local B = Image[index+4]
		
		Pixel.Position = UDim2.new(0,X,0,Y)
		Pixel.BackgroundColor3 = Color3.fromRGB(R,G,B)
		index = index + 5 --  add 5, cause there are 5 objects for each pixel, x y and r g b, due to an idea I have, it could soon be 3, by using UIGridLayout, so I'd be completely able to ditch getting the pixel size, only the initial one
		
		warn("X:" ..X .." Y:" ..Y .." R:" ..R .." G:" ..G .." B:" ..B)
	
		RunNum = RunNum+1
	end)
end

